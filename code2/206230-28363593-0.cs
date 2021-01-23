    // parse string to IExpression (symbolic type)
    IExpression expression = BaseExpression.Parse("(x+(2*x)/(1-x))");
    // create your own collection for attributes
    var attributes = new MathAttributeCollection();
    // create local variable named "x" with value 5
    var attributeX = new ScalarAttrInt("x") {Value = new ScalarConstInt(5)};
    attributes.Add(attributeX);
    // execute math expression where x=5
    var result = expression.Execute(attributes);
    MessageBox.Show(result.GetText());
    // result: 2.5
