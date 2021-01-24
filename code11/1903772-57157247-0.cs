    //note, this is high level connection interface, with functional 
    //it's often done by communicating Id's
    public interface IConnection
    {
        void ConnectPerson(int personId);
        void DisconnectPerson(int personId);
        //Sadegh Javanmard's suggested delegate handler:
        void OnNotResponding(int personId);
    }
