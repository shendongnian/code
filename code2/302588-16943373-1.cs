    Mock<HttpSessionStateBaseProxy> Session = new Mock<HttpSessionStateBaseProxy>(MockBehavior.Loose);
    Session.CallBase = true;
    Session.Setup(x => x.SetItem(It.IsAny<string>(),It.IsAny<object>()))
            .Callback<string,object>((string index, object value) =>
            {
                if (!this.SessionItems.Contains(index)) this.SessionItems.Add(index, value);
                else this.SessionItems[index] = value;
            });
                   
            Session.Setup(s => s[It.IsAny<string>()]).Returns<string>(key =>
            {
                return this.SessionItems[key];
            });
