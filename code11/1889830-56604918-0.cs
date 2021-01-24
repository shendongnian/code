c#
public async Task<IActionResult> Action() {
    // ...
    if (this.ModelState.IsValid)
    {
        var result = await TryUpdateModelAsync(Model, Model.GetType(), "");
        if (!result)
           throw new Exception("TxServerController.TxMap: TryUpdateModelAsync failed");
    }
    ModelState.Clear();
}
