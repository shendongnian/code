    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public class MyButton : Button
    {
        [TypeConverter(typeof(FormTypeConverter))]
        public Type Form { get; set; }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Form != null && typeof(Form).IsAssignableFrom(Form))
            {
                using (var f = (Form)Activator.CreateInstance(Form))
                    f.ShowDialog();
            }
        }
    }
