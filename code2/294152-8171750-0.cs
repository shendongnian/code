    [Serializable(), XmlRoot("hibernate-mapping", Namespace = "urn:nhibernate-mapping-2.2")]
    public class HibernateMapping : IXmlSerializable
    {
        public string AssemblyName { get; set; }
        public string NamespaceName { get; set; }
        public Class Class { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(NamespaceName);
            sb.Append(".");
            sb.Append(Class.Name);
            return sb.ToString();
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            AssemblyName = reader["assembly"];
            NamespaceName = reader["namespace"];
            XmlSerializer classSerializer = new XmlSerializer(typeof(Class));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "class":
                            Class = (Class)classSerializer.Deserialize(reader.ReadSubtree());
                            break;
                    }
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
    public class Column
    {
        public string ColumnName { get; set; }
        public string SqlTypeName { get; set; }
        public bool NotNull { get; set; }
    }
    public class Generator
    {
        public string Class { get; set; }
    }
    public class Id
    {
        public Generator Generator { get; set; }
        public Column Column { get; set; }
    }
    public class Property
    {
        public string Name { get; set; }
        public string Column { get; set; }
        public string SqlTypeName { get; set; }
        public bool NotNull { get; set; }
        public Column PropColumn { get; set; }
        public string GetColumnName()
        {
            if (PropColumn != null) { return PropColumn.ColumnName; }
            else { return Name; }
        }
        public string GetSqlTypeName()
        {
            if (PropColumn != null) { return PropColumn.SqlTypeName; }
            else { return SqlTypeName; }
        }
        public bool GetNotNull()
        {
            if (PropColumn != null) { return PropColumn.NotNull; }
            else { return NotNull; }
        }
    }
    [Serializable(), XmlRoot("class")]
    public class Class : IXmlSerializable
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public bool Lazy { get; set; }
        public Id Id { get; set; }
        public Property[] Properties { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Name = reader["name"];
            Table = reader["table"];
            Lazy = Convert.ToBoolean(reader["lazy"]);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "id":
                            ReadIdXml(reader.ReadSubtree());
                            break;
                        case "property":
                            ReadPropertyXml(reader.ReadSubtree());
                            break;
                    }
                }
            }
        }
        private void ReadIdXml(XmlReader reader)
        {
            //you can read the attributes and subnodes of the id node as above...
            Id = new Id();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "generator":
                            Id.Generator = new Generator();
                            Id.Generator.Class = reader["class"];
                            break;
                        case "column":
                            Id.Column = ReadColumnXml(reader.ReadSubtree());
                            break;
                    }
                }
            }
        }
        private void ReadPropertyXml(XmlReader reader)
        {
            Property property = new Property();
            property.Name = reader["name"];
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "generator":
                            property.PropColumn = ReadColumnXml(reader.ReadSubtree());
                            break;
                    }
                }
            }
        }
        private Column ReadColumnXml(XmlReader reader)
        {
            Column column = new Column();
            column.ColumnName = reader["name"];
            column.SqlTypeName = reader["sql-type"];
            column.NotNull = Convert.ToBoolean(reader["non-null"]);
            return column;
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
