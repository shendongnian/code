    public class PopupForm : Form
    {
      private Action _onAccept;
      private Control _control;
      private Point _point;
      public PopupForm(Control control, int x, int y, Action onAccept)
        : this(control, new Point(x, y), onAccept)
      {
      }
      public PopupForm(Control control, Point point, Action onAccept)
      {
        if (control == null) throw new ArgumentNullException("control");
        this.FormBorderStyle = FormBorderStyle.None;
        this.ShowInTaskbar = false;
        this.KeyPreview = true;
        _point = point;
        _control = control;
        _onAccept = onAccept;
      }
      protected override void OnLoad(EventArgs e)
      {
        base.OnLoad(e);
        this.Controls.Add(_control);
        _control.Location = new Point(0, 0);
        this.Size = _control.Size;
        this.Location = _point;
      }
      protected override void OnKeyDown(KeyEventArgs e)
      {
        base.OnKeyDown(e);
        if (e.KeyCode == Keys.Enter)
        {
          _onAccept();
          this.Close();
        }
        else if (e.KeyCode == Keys.Escape)
        {
          this.Close();
        }
      }
      protected override void OnDeactivate(EventArgs e)
      {
        base.OnDeactivate(e);
        this.Close();
      }
    }
