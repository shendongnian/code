        using System.Windows.Controls;
        namespace ScrollBarTest
        {
        	public class CustomListBox : ListBox
        	{
        	    public void ScrollToBottom()
        		{
        			var scrollviewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
        			scrollviewer.ScrollToVerticalOffset(scrollviewer.ScrollableHeight);
        		}
        	}
        }
