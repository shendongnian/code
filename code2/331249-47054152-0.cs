        //
        // Summary:
        //     Delete all entities selected by the specified query. The delete operation is
        //     performed in the database without reading the entities out of it.
        //
        // Parameters:
        //   source:
        //     The query matching the entities to delete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source.
        //
        // Returns:
        //     The number of deleted entities.
        public static int Delete<TSource>(this IQueryable<TSource> source);
