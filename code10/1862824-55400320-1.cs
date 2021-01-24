    public class SampleClass : IControl
    {
        void IControl.Paint()
        {
            System.Console.WriteLine("IControl.Paint");
        }
    }
    IControl ctrl = new SampleClass();
    ctrl.Paint(); //possible
    SampleClass ctrl = new SampleClass();
    ctrl.Paint(); //not possible
    var ctrl = new SampleClass();
    ctrl.Paint(); //not possible
