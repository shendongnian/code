    class move_basic
    {
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            // Name this move
            string name = "Attack!";
            // Describe this move
            string description = "Strike out at the enemy with tooth, claw, weapon, or whatever else is available!";
            // Choose the type of target this move is for
            // self/ally/selfAlly/enemy/enemies
            string target = "enemy";
            // The move typing - This determines cost reduction as well as potential attack bonuses
            string typeName = "physical";
            game_Type type = game_Types.Types.Find(x => x.name == typeName);
            // The move style - This determines additional bonuses and modifiers
            string styleName = "martial";
            // Style style = ??
            // Power of the move, base/'normal' power is 50.
            int power = 50;
            // Accuracy of the move, base/normal is 90
            int accuracy = 90;
            // MP Cost of the move
            int cost = 0;
            Move mv = new Move(name, description, power, accuracy, cost, typeName, styleName, target);
        }
    }
