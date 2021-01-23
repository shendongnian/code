    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using ComIDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
    
    public static class DragDropEngine
    {
          public static void ProcessDragEnter(DragEventArgs e)
          {
                Point point = Cursor.Position;
                WindowsPoint winpoint;
                winpoint.X = point.X;
                winpoint.Y = point.Y;
                IDropTargetHelper dropHelper = (IDropTargetHelper)new DragDropHelper();
                dropHelper.DragEnter(IntPtr.Zero, (ComIDataObject)e.Data, 
                      ref winpoint, (int)e.Effect);
          }
          public static void ProcessDragDrop(DragEventArgs e)
          {
                Point point = Cursor.Position;
                WindowsPoint winpoint;
                winpoint.X = point.X;
                winpoint.Y = point.Y;
                IDropTargetHelper dropHelper = (IDropTargetHelper)new DragDropHelper();
                dropHelper.Drop((ComIDataObject)e.Data, ref winpoint, (int)e.Effect);
          }
          public static void ProcessDragOver(DragEventArgs e)
          {
                Point point = Cursor.Position;
                WindowsPoint winpoint;
                winpoint.X = point.X;
                winpoint.Y = point.Y;
                IDropTargetHelper dropHelper = (IDropTargetHelper)new DragDropHelper();
                dropHelper.DragOver(ref winpoint, (int)e.Effect);
          }
          public static void ProcessDragLeave(EventArgs e)
          {
                IDropTargetHelper dropHelper = (IDropTargetHelper)new DragDropHelper();
                dropHelper.DragLeave();
          }
    }
    [ComImport]
    [Guid("4657278A-411B-11d2-839A-00C04FD918D0")]
    public class DragDropHelper
    {
    }
    [ComVisible(true)]
    [ComImport]
    [Guid("4657278B-411B-11D2-839A-00C04FD918D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTargetHelper
    {
          void DragEnter(
              [In] IntPtr hwndTarget,
              [In, MarshalAs(UnmanagedType.Interface)] 
                System.Runtime.InteropServices.ComTypes.IDataObject dataObject,
              [In] ref WindowsPoint pt,
              [In] int effect);
          void DragLeave();
          void DragOver(
              [In] ref WindowsPoint pt,
              [In] int effect);
          void Drop(
              [In, MarshalAs(UnmanagedType.Interface)] 
                System.Runtime.InteropServices.ComTypes.IDataObject dataObject,
              [In] ref WindowsPoint pt,
              [In] int effect);
          void Show(
              [In] bool show);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowsPoint
    {
          public int X;
          public int Y;
    }
