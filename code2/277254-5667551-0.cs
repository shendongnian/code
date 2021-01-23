    pubic void BigDinnerEatingProcess()
    {
        try
        {
             WhateverHappensAtTheTopLevel();
        }
        catch (PizzaNotDeliveredException ex)
        {
             Utilities.PostError(ex);
             MessageBox.Show("Dinner was not eaten. Please make sure the pizza is delivered.");
        }
    }
    
    public void EatPizza(Pizza p)
    {
        if (p == null)
            throw new PizzaNotDeliveredException();
        p.RemoveOneSlice();
    }
    
    private void PostError(Exception ex)
    {
        string errorLocation = ex.StackTrace;
        //...
    }
