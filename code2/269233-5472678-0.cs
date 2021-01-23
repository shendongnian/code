        [Serializable]
        public struct TempContato
        {
            public int IDCliente { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Cpf { get; set; }
            public string Rg { get; set; }
            public string Departamento { get; set; }
            public string Cargo { get; set; }
        }
        protected List<TempContato> ListaTabelaTemp
        {
            get
            {
                if (this.ViewState["ListaTempContato"] == null)
                    this.ViewState["ListaTempContato"] = new List<TempContato>();
                return (List<TempContato>)this.ViewState["ListaTempContato"];
            }
        }
        protected void AddItem()
        {
            TempContato tempContato = new TempContato();
            //tempContato.IDCliente = Convert.ToInt32(this.txtEmailContato.Text);
            tempContato.Nome = this.txtNomeContato.Text;
            tempContato.Email = this.txtEmailContato.Text;
            tempContato.Telefone = this.txtTelefoneContato.Text;
            tempContato.Cpf = this.txtCpfContato.Text;
            tempContato.Rg = this.txtRgContato.Text;
            tempContato.Departamento = this.ddlDepartamentoContato.SelectedValue;
            tempContato.Cargo = this.ddlCargoContato.SelectedValue;
            this.ListaTabelaTemp.Add(tempContato);
        }
        protected void AtualizarGrid()
        {
            this.gvContato.DataSource = this.ListaTabelaTemp;
            this.gvContato.DataBind();
        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            this.AddItem();
            this.AtualizarGrid();
        }
