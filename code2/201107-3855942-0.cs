	void btnSubmit_Click(object sender, EventArgs e) {
		//DO SOMETHING
		if (success) {
			OnSomethingCompleted();
		}
	}
	///<summary>Occurs when the operation is successfully completed.</summary>
	public event EventHandler SomethingCompleted;
	///<summary>Raises the SomethingCompleted event.</summary>
	internal protected virtual void OnSomethingCompleted() { OnSomethingCompleted(EventArgs.Empty); }
	///<summary>Raises the SomethingCompleted event.</summary>
	///<param name="e">An EventArgs object that provides the event data.</param>
	internal protected virtual void OnSomethingCompleted(EventArgs e) {
		if (SomethingCompleted != null)
			SomethingCompleted(this, e);
	}
