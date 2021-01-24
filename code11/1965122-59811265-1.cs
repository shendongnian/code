cs
class Calculator
{
    private int operand1;
    private int operand2;
    public Calculator(int operand1, int operand2)
    {
        this.operand1 = operand1;
        this.operand2 = operand2;
    }
    public string WriteText(string s)
    {
        return s;
    }
    public int WriteNumber(int n)
    {
        return n;            
    }
}
cs
var calculator = new Calculator(operand1, operand2);
string s = calculator .WriteText("Hello world!");
Console.WriteLine(s);
int n = calculator .WriteNumber(53 + 28);
Console.WriteLine(n);
