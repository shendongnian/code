    <script runat="server">
        protected override void OnInit(EventArgs e)
        {
            Ext.Net.Button btn = new Ext.Net.Button();
    
            btn.Text = "Submit (DirectEvent)";
            // 2. CHANGE to .DirectClick 
            btn.DirectClick += Button1_Click;
            // 3. REMOVE btn.AutoPostBack = true;
            this.ViewPort1.Items.Add(btn);
            
            base.OnInit(e);
        }
        // 3. CHANGE "EventArgs" to "DirectEventArgs"    
        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            X.Msg.Notify("Server Time", DateTime.Now.ToLongTimeString()).Show();
        }
    </script>
