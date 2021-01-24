Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() => {
                prova(); })); 
with: 
void prova ()
        {
            OutButton btn = m_Bblock.AllOutBtn[0];
            Point pt = btn.TransformToAncestor(GridDropAccept).Transform(new Point(0, 0));
        }
That works like a charm for me.
