    public CheckMenuItem (string label) : base (IntPtr.Zero)
    {
        if (GetType() != typeof (CheckMenuItem)) {
            CreateNativeObject (new string [0], new GLib.Value [0]);
            AccelLabel al = new AccelLabel ("");
            al.TextWithMnemonic = label;
            al.SetAlignment (0.0f, 0.5f);
            Add (al);
            al.AccelWidget = this;
            return;
        }
        IntPtr native = GLib.Marshaller.StringToPtrGStrdup (label);
        Raw = gtk_check_menu_item_new_with_mnemonic (native);
        GLib.Marshaller.Free (native);
    }
