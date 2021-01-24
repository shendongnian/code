    public class Query : ObjectGraphType {
        public Query(Context db) {
            Name = "query";
            Field<ListGraphType<Types.Note>>("notes", resolve: _ => db.Notes.AsAsyncEnumerable());
        }
    }
