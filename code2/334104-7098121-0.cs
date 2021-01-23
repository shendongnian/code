        public class MyAggregateRoot
        {
            protected MyEntity entity;
    
            public void BuildUpAggregate()
            {
                ValidateSomeRule();
                LoadEntityFromDatabase();
            }
    
            public MyEntity MyEntity
            {
                get 
                {
                    VerifySomeOtherRule();
                    return entity; 
                }
            }
        }
