    [assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
    namespace Testapp.Droid
    {
    	public class CustomViewCellRenderer : ViewCellRenderer
    	{
    
    		protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
    		{
    			var cell = base.GetCellCore(item, convertView, parent, context);
    
    			//switch (item.StyleId)
    			//{
    			//	case "disclosure":
    					
    			//		break;
    			//}
    
    
    
                var bmp = BitmapFactory.DecodeResource(cell.Resources, Resource.Drawable.arrow);
                var bitmapDrawable = new BitmapDrawable(cell.Resources, Bitmap.CreateScaledBitmap(bmp, 50, 50, true));
                bitmapDrawable.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;
                cell.SetBackground(bitmapDrawable);
    
    
                return cell;
    		}
    	}
    }
