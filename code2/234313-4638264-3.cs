    EuroBank : IBank
    {
        void AddMoney(int amount){ balance+= amount; }
        void RemoveMoney(int amount){ balance-= amount; }
        int GetBalance(){ return balance; }
        private int balance;
    }
