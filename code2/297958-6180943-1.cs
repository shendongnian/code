    static void Main() {
        Expression<Func<Agency, AgencyDTO>> selector1 = x => new AgencyDTO { Name = x.Name };
        Expression<Func<Agency, AgencyDTO>> selector2 = x => new AgencyDTO { Phone = x.PhoneNumber };
        Expression<Func<Agency, AgencyDTO>> selector3 = x => new AgencyDTO { Location = x.Locality.Name };
        Expression<Func<Agency, AgencyDTO>> selector4 = x => new AgencyDTO { EmployeeCount = x.Employees.Count() };
        // combine the assignments from the 4 selectors
        var convert = Combine(selector1, selector2, selector3, selector4);
        // sample data
        var orig = new Agency
        {
            Name = "a",
            PhoneNumber = "b",
            Locality = new Location { Name = "c" },
            Employees = new List<Employee> { new Employee(), new Employee() }
        };
        // check it
        var dto = new[] { orig }.AsQueryable().Select(convert).Single();
        Console.WriteLine(dto.Name); // a
        Console.WriteLine(dto.Phone); // b
        Console.WriteLine(dto.Location); // c
        Console.WriteLine(dto.EmployeeCount); // 2
    }
    static Expression<Func<TSource, TDestination>> Combine<TSource, TDestination>(
        params Expression<Func<TSource, TDestination>>[] selectors)
    {
        var zeroth = ((MemberInitExpression)selectors[0].Body);
        var param = selectors[0].Parameters[0];
        List<MemberBinding> bindings = new List<MemberBinding>(zeroth.Bindings.OfType<MemberAssignment>());
        for (int i = 1; i < selectors.Length; i++)
        {
            var memberInit = (MemberInitExpression)selectors[i].Body;
            var replace = new ParameterReplaceVisitor(selectors[i].Parameters[0], param);
            foreach (var binding in memberInit.Bindings.OfType<MemberAssignment>())
            {
                bindings.Add(Expression.Bind(binding.Member,
                    replace.VisitAndConvert(binding.Expression, "Combine")));
            }
        }
        return Expression.Lambda<Func<TSource, TDestination>>(
            Expression.MemberInit(zeroth.NewExpression, bindings), param);
    }
    class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression from, to;
        public ParameterReplaceVisitor(ParameterExpression from, ParameterExpression to)
        {
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == from ? to : base.VisitParameter(node);
        }
    }
