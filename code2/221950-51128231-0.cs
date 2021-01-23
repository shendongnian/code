        /// <summary>
        ///     Exibe texto do controle num tipo ToolTip do winform
        /// </summary>
        /// <param name="controle">Controle</param>
        /// <param name="icon"></param>
        public static void ShowTextToolTip(Control controle, ToolTipIcon icon)
        {
            try
            {
                var tooltip = new ToolTip();
                tooltip.ToolTipIcon = icon;
                controle.MouseHover += (k, args) => { tooltip.SetToolTip(controle, controle.Text); };
            }
            catch (Exception)
            {
            }
        }
