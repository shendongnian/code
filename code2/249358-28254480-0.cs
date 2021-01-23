    boolean noMod = ModifierKeys == ModifierKeys.None;
    KeyBinding inputBinding = new KeyBinding(this, Keys, noMod ? ModifierKeys.Alt : ModifierKeys));
    if (noMod)
    {
        inputBinding.ClearValue(KeyBinding.ModifiersProperty);
    }
