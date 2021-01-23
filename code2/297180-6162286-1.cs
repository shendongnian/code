                MainGroup main = new MainGroup
                {
                    A = new GroupA { Name = "GroupA", ID = 1 },
                    B = new GroupB { Date = DateTime.UtcNow },
                    C = new GroupC { HasData = false }
                };
    
                Reflect(main);
