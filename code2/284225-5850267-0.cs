        public static T CallFunc<T>( Func<T> theFunc )
        {
            return theFunc();
        }
        ... 
        var activities = CallFunc( () =>
        {
            using( var context = new MyEntities() )
            {
                return 
                    (
                        from act in context.Activities
                        where act.ActTwittered == false
                        select new { act.ActID, act.ActTitle, act.Category, act.ActDateTime, act.Location };
                    )
                    .ToList();
            }
        }
