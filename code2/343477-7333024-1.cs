    public abstract class TerminalFileSizeExpression : FileSizeExpression
    {
        public override void Interpret(FileSizeContext value)
        {
            if(value.Input.EndsWith(this.ThisPattern()))
            {
                double amount = double.Parse(value.Input.Replace(this.ThisPattern(),String.Empty));
                var fileSize = (int)(amount*1024);
                value.Input = String.Format("{0}{1}",fileSize,this.NextPattern());
                value.Output = fileSize;
            }
        }
        protected abstract string ThisPattern();
        protected abstract string NextPattern();
    }
    public class KbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern(){return "Kb";}
        protected override string NextPattern() { return "bytes"; }
    }
    public class MbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "Mb"; }
        protected override string NextPattern() { return "Kb"; }
    }
    public class GbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "Gb"; }
        protected override string NextPattern() { return "Mb"; }
    }
    public class TbFileSizeExpression : TerminalFileSizeExpression
    {
        protected override string ThisPattern() { return "Tb"; }
        protected override string NextPattern() { return "Gb"; }
    }
