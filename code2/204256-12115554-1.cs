	public frmGoods()
	{
		InitializeComponent();
		this.sellingVATDataGridViewTextBoxColumn.CellTemplate = new VATGridViewTextBoxCell();
		this.buyingVATDataGridViewTextBoxColumn.CellTemplate = new VATGridViewTextBoxCell();
	}
