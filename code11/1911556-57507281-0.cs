    public class OrderDto
    {
        public string Name { get; set; }
    
        public int Amount { get; set; }
    }
    
    public class FilterOrdersQuery : IRequest<List<OrderDto>>
    {
        public string Filter { get; set; }
    }
    
    public class FilterOrdersQueryHandler : IRequestHandler<FilterOrdersQuery, List<OrderDto>>
    {
        public Task<List<OrderDto>> Handle(FilterOrdersQuery notification, CancellationToken cancellationToken)
        {
            var dataSource = new List<OrderDto>(){
                new OrderDto()
                {
                    Name = "blah",
                    Amount = 65
                },
                new OrderDto()
                {
                    Name = "foo",
                    Amount = 12
                },
            };
                        
            var result = dataSource
                .Where(x => x.Name.Contains(notification.Filter))              
                .ToList();
    
            return Task.FromResult(result);
        }
    }
