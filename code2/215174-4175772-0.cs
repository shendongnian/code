    var result = vendorContract.Item.Where(x => x.ItemNumber == contractItem.Item_Number).GetEnumerator();
    if (result.MoveNext) {
        var oldDbContractItem = result.Current;
        // ...
    }
