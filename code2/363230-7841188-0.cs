    class Test
    {
    }
    dynamic dyn = new Test();
    Test[] tests = null;
    if (dyn is Test)
    {
        tests = new Test[] { (Test)dyn };
    }
    else if (dyn is Test[])
    {
        tests = (Test[])dyn;
    }
