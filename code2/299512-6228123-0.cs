    [TestMethod]
    [Description("Tests that the currency ComboBox is databound correctly")]
    public void TestCurrencySelection()
    {
        _target.LayoutUpdated += (s, e) =>
            {
                SetupViewModel();
                var currencyCombo = GetUIElement<ComboBox>("cmbCurrency");
                CollectionAssert.AreEquivalent(currencyCombo.Items,
                                               _currencies,
                                               "Failed to data-bind currencies list.");
                Assert.AreEqual(currencyCombo.SelectedValue,
                                _viewModel.CurrencyId,
                                "Failed to data-bind selected currency.");
            };
        TestPanel.Children.Add(_target);
    }
