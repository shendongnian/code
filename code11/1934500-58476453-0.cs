class Button
{
    byte action = 0;
    public Action{get; set;}
    void TakeAction(int action)
    {
        switch (action)
        {
            case 0:
                HEB f1 = new HavamalEB();
                break;
            case 1:
                HEB f1 = new HavamalEB();
                break;
        }
    }
}
or something similar, I am not sure how your surrounding code looks.
Hope this was helpful and a valid solution. Good luck!
