public class Imple : choices    
{    
    private int effectNum = 1; // set the default effect here
    public void Choose(int index)    
    {    
        effectNum = index;   
    }
    public void Effect()
    {
        switch (effectNum)
        {
            case 1: // implement the different effects here
                break;
            case 2:
                break;
        }
    }
}
