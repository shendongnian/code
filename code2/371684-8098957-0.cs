Per Hans' suggestion, it did require a ControlDesigner. I created a simple designer that would interface with some internal properties, and I did get it to work. Here's the catch, though: It's a bit of a hack. There doesn't seem to be a single field that has the value I'm looking for, so I had to do a .ToString() on an object, then parse out the first section. I figured that's about as clean as it is going to get.
    public class MyControlDesigner : ControlDesigner
    {
        public MyControlDesigner()
        {
        }
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            MyControl control1 = this.Component as MyControl;
            control1.LabelText = control1.ToString().Split(" ".ToCharArray())[0];
        }
    }
