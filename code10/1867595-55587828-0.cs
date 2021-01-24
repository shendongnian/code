public class DynamicVariableSheet
{
     public SendBackOptions SendBackOptions { get; set; }
     public ForwardOptions ForwardOptions { get; set; }
}
public class SendBackOptions
{
     public byte IsCancellingBrothersNode { get; set; }
}
public class ForwardOptions
{
     public string SignForwardCompareType { get; set; }
     public float SignForwardCompleteOrder { get; set; }
}
