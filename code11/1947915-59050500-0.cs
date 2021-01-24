using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.UWP;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
[assembly:ExportRenderer(typeof(DatePicker),typeof(MyPickerRenderer))]
namespace xxx.UWP
{
    public class MyPickerRenderer:DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                Control.MonthFormat = "{month.integer}";
            }
        }
    }
}
