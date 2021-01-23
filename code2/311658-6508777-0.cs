    public void AgreeTerms_Clicked(object sender, EventArgs e)
    {
        if (AgreeTerms.Checked)
            OnTermsAgreed();
    }
    private void OnTermsAgreed()
    {
        // raise TermsAgreed event
        var evt = TermsAgreed;
        if (null != evt)
            evt(this, EventArgs.Empty);
    }
    public event EventHandler TermsAgreed;
