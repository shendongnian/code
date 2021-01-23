Application.AddMessageFilter(new MyMessageFilter());
class MyMessageFilter:IMessageFilter
{
    void PreFilterMessage(ref Message m)
    {
        Control target=Control.FromHandle(m.HWnd);
        //if(target!=null)
        switch((WM)m.Msg)
        {
            case WM.LBUTTONDOWN://left mouse click
            uint x=((uint)m.LParam)&0xFFFF;
            uint y=((uint)m.LParam)>>16;
            ...
            break;
        }
    }
}
