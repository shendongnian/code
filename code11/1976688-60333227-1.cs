        ...
    
        float value = BitConverter.ToSingle(dest, 0);
        string text = value.ToString();
        
        actions.Enqueue(() => 
        {
            text2 = text;
            // print text
            print(">> " + text);
        }
    }
    catch(Exception err
    {
        actions.Enqueue(() => print(err.ToString());
    }
