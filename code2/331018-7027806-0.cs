       private void YourFunction
        {
            Type TrType = this.GetType();
            MooClass Moo = new MooClass();
            LabelTypeEnum LabelType = LabelTypeEnum.something;
            ShowIf(Moo, TrType, LabelType, a => { return a.Foo.DangerousNullRef + " - " + a.Foo.AnotherPossibleNullRef; });
          }
 
       void ShowIf(MooClass Moo, Type t, LabelTypeEnum LabelType, Func<MooClass, string> mc )
        {
            if (Moo.Foo != null)
                Show(t, LabelType, mc(Moo));
            else
                DontShowField(t);
        }
