    #region SubscriptionFee
    
    /// <summary>
    /// SubscriptionFee Dependency Property
    /// </summary>
    public static readonly DependencyProperty SubscriptionFeeProperty =
    	DependencyProperty.Register( "SubscriptionFee_2", typeof( decimal ), typeof( EditMembershipViewModel ),
    		new FrameworkPropertyMetadata( (decimal)0 ) );
    
    /// <summary>
    /// Gets or sets the SubscriptionFee property. This dependency property
    /// indicates the new subscription fee for the customer.
    /// </summary>
    public decimal SubscriptionFee
    {
    	get { return (decimal)GetValue( SubscriptionFeeProperty ); }
    	set { SetValue( SubscriptionFeeProperty, value ); }
    }
    
    #endregion SubscriptionFee
