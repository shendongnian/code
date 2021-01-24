    public static class StudentExt {
        public static IQueryable<Student> FilterAfterDate(this IQueryable<Student> query,
            Expression<Func<Student, DateTime>> GetDateExpression, DateTime now) {
            Expression<Func<DateTime,bool>> templateFn = x => x > now;
            var filterFn = Expression.Lambda<Func<Student,bool>>(templateFn.Body.Replace(templateFn.Parameters[0], GetDateExpression.Body), GetDateExpression.Parameters);
    
            return query.Where(filterFn);
        }
    }
