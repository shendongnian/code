C#
public class DateConverter : IValueConverter<string, DateTime?>
{
    public DateTime? Convert(string source, ResolutionContext context)
    {
        if(DateTime.TryParse(source, out DateTime result))
            return result;
        return null;
    }
}
This is just a quick example of a possible value converter. When the string is succesfully paresed, you'll get a `DateTime` result, otherwise `null`. Of course ou can adjust to your needs.
You then use the ocnverter like this:
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<OrderDto, Order>()
           .ForMember(d => d.orderDate, opt => opt.ConvertUsing(new DateConverter()));
    });
    var mapper = config.CreateMapper();
    var orderDTO = new OrderDto();
    orderDTO.id = 1;
    orderDTO.orderDate = "2020-01-01";
    var order = mapper.Map<Order>(orderDTO); // orderDate will be null 2020-01-01
    orderDTO.orderDate = "10-31";
    var otherorder = mapper.Map<Order>(orderDTO); // orderDate will be null
  [1]: https://automapper.readthedocs.io/en/latest/Value-converters.html
