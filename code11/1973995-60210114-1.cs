    var target = new TargetObject(lookup);
    target.TestFunc((x, y) => {
        // x is the key
        // y is the subitem
        // Whatever code you put here will run once for every subitem.
        // And you will be able to use properties and methods of y.
        // As a bonus, you also have access to variables in outer scope via closures.
    });
