public class ChildDtoTmp : ChildDto { }
public class RandomDto
{
    public int Id { get; set; }
    public ChildDto FirstChild { get; set; }
    public ChildDtoTmp SecondChild { get; set; }
}
This worked fine, but because the type of the navigation proerty has another navigation property the same strange behaviour shows up with the nested navigation property.
public class ChildDto
{
    public int Id { get; set; }
    public InnerChildDto InnerChild { get; set; }
}
This leads to the properties ```FirstChild``` and ```SecondChild``` being mapped, but only the ```InnerChild``` property of the ```FirstChild``` gets mapped.
Maybe this helps someone to figure out how to solve this.
