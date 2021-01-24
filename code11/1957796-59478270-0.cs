using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xxx.iOS;
[assembly:ExportRenderer(typeof(ViewCell),typeof(MyCellRenderer))]
namespace xxx.iOS
{
    public class MyCellRenderer:ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            
         //   reusableCell.EditingAccessory = UITableViewCellAccessory.DisclosureIndicator;
            var cell =  base.GetCell(item, reusableCell, tv);
            cell.Accessory = UITableViewCellAccessory.None;
            return cell;
        }
    }
}
