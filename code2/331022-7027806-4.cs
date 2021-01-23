       private void YourFunction
        {
            Type TrType = this.GetType();
            MooClass Moo = new MooClass();
            LabelTypeEnum LabelType = LabelTypeEnum.something;
            ShowIf(Moo, TrType, LabelType, new Object[] { Moo.Foo, Moo.Foo2, Moo.Foo3 }, a => a.Foo.DangerousNullRef + " - " + a.Foo.AnotherPossibleNullRef);
        }
 
        void ShowIf(MooClass Moo, Type t, LabelTypeEnum LabelType, IEnumerable<object> PreCheckNullsValues, Func<MooClass, string> mc )
        {
            if (PreCheckNullsValues.Any(a => a == null))
                Show(t, LabelType, mc(Moo));
            else
                DontShowField(t);
        }
