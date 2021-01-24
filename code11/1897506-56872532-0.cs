c#
        public Page DoAction(Object object)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                pageInput.SendKeys(object.field);
            }, "Action");
            return new HomePage();
        }
