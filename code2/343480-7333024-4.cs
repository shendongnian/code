    public abstract class TerminalFileSizeExpression : FileSizeExpression
    {
        public override void Interpret(FileSizeContext value)
        {
            if(value.Input.EndsWith(this.ThisPattern()))
            {
                double amount = double.Parse(value.Input.Replace(this.ThisPattern(),String.Empty));
                var fileSize = (long)(amount*1024);
                value.Input = String.Format("{0}{1}",fileSize,this.NextPattern());
                value.Output = fileSize;
            }
        }
        protected abstract string ThisPattern();
        protected abstract string NextPattern();
    }
    public class KbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern(){return "KB";}
        protected override string NextPattern() { return "bytes"; }
    }
    public class MbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "MB"; }
        protected override string NextPattern() { return "KB"; }
    }
    public class GbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "GB"; }
        protected override string NextPattern() { return "MB"; }
    }
    public class TbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "TB"; }
        protected override string NextPattern() { return "GB"; }
    }
