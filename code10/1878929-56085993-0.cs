cs
switch (Row.ISO2){
    case "Value1":
        Output1Buffer.AddRow();
        Output1Buffer.Column = Row.Column;
        break;
    case "Value2":
        Output2Buffer.AddRow();
        Output2Buffer.Column = Row.Column;
        break;
 
    case "Value3":
        Output3Buffer.AddRow();
        Output3Buffer.Column = Row.Column;
        break;
    default:
        Output4Buffer.AddRow();
        Output4Buffer.Column = Row.Column;
        break;
}
*Make sure that all output don't have a Synchronous Input and that this property is set to `None`.*
