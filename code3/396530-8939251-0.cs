    // Create a ocx state object with the correct path
    _Unity = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
    ((System.ComponentModel.ISupportInitialize)(_Unity)).BeginInit();
    _Unity.OcxState = (AxHost.State)(Resources.Unity3DOcx);
    _Unity.TabIndex = 0;
    Controls.Add(_Unity);
    ((System.ComponentModel.ISupportInitialize)(_Unity)).EndInit();
    _Unity.src = _File;
    AxHost.State state = _Unity.OcxState;
    _Unity.Dispose();
    // Create the unity web player object
    _Unity = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
    ((System.ComponentModel.ISupportInitialize)(_Unity)).BeginInit();
    this.SuspendLayout();
    _Unity.Dock = DockStyle.Fill;
    _Unity.Name = "Unity";
    _Unity.OcxState = state;
    _Unity.TabIndex = 0;
    Controls.Add(_Unity);
    ((System.ComponentModel.ISupportInitialize)(_Unity)).EndInit();
    this.ResumeLayout(false);
