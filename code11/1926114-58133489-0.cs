type Character {
  name: String!
  appearsIn: [Episode]!
}
A Character is ObjectGraphType, but appearsIn is a ListGraphType(it can be also a ObjectGraphType depending on the Type) of Type Episode ObjectGraphType. So the appearsIn has all the fields that can be also found in Episode Type. 
Which brings me to here I'll do some pseudo just that if someone reads this gets a understading of what to do next, in the TableType:
public class TableType : ObjectGraphType<object>
    {
        public TableType (TableMetadata tableMetadata)
        {
            Name = tableMetadata.TableName;
            foreach (var tableColumn in tableMetadata.Columns)
            {
                InitGraphTableColumn(tableColumn);
            }
            TableArgs.Add(new QueryArgument<IdGraphType> { Name = "id" });
            TableArgs.Add(new QueryArgument<IntGraphType> { Name = "first" });
            TableArgs.Add(new QueryArgument<IntGraphType> { Name = "offset" });
            TableArgs.Add(new QueryArgument<StringGraphType> { Name = "includes" });
        }
        public QueryArguments TableArgs
        {
            get; set;
        }
        private IDictionary<string, Type> _databaseTypeToSystemType;
        protected IDictionary<string, Type> DatabaseTypeToSystemType
        {
            get
            {
                if (_databaseTypeToSystemType == null)
                {
                    _databaseTypeToSystemType = new Dictionary<string, Type>
                    {
                         { "uniqueidentifier", typeof(String) },
                        { "char", typeof(String) },
                        { "nvarchar", typeof(String) },
                        { "int", typeof(int) },
                        { "decimal", typeof(decimal) },
                        { "bit", typeof(bool) }
                    };
                }
                return _databaseTypeToSystemType;
            }
        }
        private void InitGraphTableColumn(ColumnMetadata columnMetadata)
        {
        //here check with a if statement is the column.field a object
        // if it is a object make a new fieldtype based on that object
        // pass a resolver to the field
            var graphQLType = ResolveColumnMetaType(columnMetadata.DataType).GetGraphTypeFromType(true);
            var columnField = Field(
                graphQLType,
                columnMetadata.ColumnName
            );
            columnField.Resolver = new NameFieldResolver();
            FillArgs(columnMetadata.ColumnName);
        }
        private void FillArgs(string columnName)
        {
            if(TableArgs == null)
            {
                TableArgs = new QueryArguments(
                    new QueryArgument<StringGraphType>()
                    {
                        Name = columnName
                    });
            }
            else
            {
                TableArgs.Add(new QueryArgument<StringGraphType> { Name = columnName });
            }
        }
        private Type ResolveColumnMetaType(string dbType)
        {
            if (DatabaseTypeToSystemType.ContainsKey(dbType))
                return DatabaseTypeToSystemType[dbType];
            return typeof(String);
        }
So in essence a graph can have a name,fields, and a resolver, but the field can be of a another type, and while creating a type we can simply invoke a creation of a field which is from another type, and we have our relation that is a child relation that is from the type we need, and gain access to the fields of that type.
 private void InitGraphTableColumn(ColumnMetadata columnMetadata)
        {
        //here check with a if statement is the column.field a object
        // if it is a object make a new fieldtype based on that object
        // pass a resolver to the field
            var graphQLType = ResolveColumnMetaType(columnMetadata.DataType).GetGraphTypeFromType(true);
This is the part which is vital.
