    public static class StudentExt {
        public static IQueryable<Student> FilterAfterDate(this IQueryable<Student> query,
            Expression<Func<Student, DateTime>> GetDateExpression, DateTime now)
            => query.AsExpandable().Where(x => GetDateExpression.Invoke(x) > now);
    }
