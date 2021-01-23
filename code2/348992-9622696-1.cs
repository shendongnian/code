        SomeRightEnum someRightEnum = SomeRightEnum.CanDoNothing;
        int newValue = 0;
        var enumValues = Enum.GetValues( someRightEnum.GetType( ) ).Cast<int>( );
        foreach ( var value in enumValues )
        {
          newValue |= value;
        }
        Console.WriteLine(newValue);
