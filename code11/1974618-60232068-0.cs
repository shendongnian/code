protected void btnMdlEditar_OnClick(object sender, EventArgs e)
        {
            NumberStyles style;
            CultureInfo provider;
            style = NumberStyles.AllowDecimalPoint;
            provider = new CultureInfo("en-US");
            decimal costoDecimal = 0;
            var costo = editCosto.Text;
            if (editCosto.Text.Contains("."))
            {
                costoDecimal = decimal.Parse(costo.ToString(), style, provider);
            }
            else if (editCosto.Text.Contains(","))
            {
                costoDecimal = decimal.Parse(costo.ToString(), style);
            }
            try
            {
                var id = CDatos.DHerramientas.UpdateHerramientas(int.Parse(txtId.Text), editCodigo.Text, editNombreCorto.Text, editDescripcion.Text, costoDecimal, editConsumible.Text);
                rgHerramientas.DataBind();
                rgHerramientas.Rebind();
                upHerramientas.Update();
                this.ShowMessage(Resources.Language.mess_insert, "success");
            }
            catch (Exception ex) { this.ShowMessage(ex.Message, "danger"); }
            this.CloseModal("mdlHerramientaEdit");
        }
Changing the culture depending if "," or "." was used
