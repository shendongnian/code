      using (ChannelFactory<IEmployeeService> ChannelFactory = new ChannelFactory<IEmployeeService>("emp"))
            {
                // ChannelFactory.Endpoint.EndpointBehaviors.Add(new MyEndpointBehavior());
                IEmployeeService employeeService = ChannelFactory.CreateChannel();
                employeeService.GetEmployee(new Employee() { Name = "abc", Department = "dep", Grade = "male", Id = "1er" });
                // List<Employee> list=  employeeService.GetList();
                Console.Read();
            }
