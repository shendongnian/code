c#
public class PacketHandler
{
    public static List<System.Type> packets = new List<System.Type>();
    public PacketHandler()
    {
        registerPacket(typeof(NMSG_CreatePlayer));
        registerPacket(typeof(NMSG_UpdatePlayer));
        registerPacket(typeof(NMSG_UpdatePlayerState));
        registerPacket(typeof(NMSG_CreateAccount));
        registerPacket(typeof(NMSG_RegisterMessage));
        registerPacket(typeof(NMSG_ConnectAccount));
        registerPacket(typeof(NMSG_ConnectionMessage));
        registerPacket(typeof(NMSG_ActivateAccountProcess));
        registerPacket(typeof(NMSG_DisconnectAccount));
        registerPacket(typeof(NMSG_PlayerDataTransmission));
        registerPacket(typeof(NMSG_UpdateAccountData));
        registerPacket(typeof(NMSG_UpdateInventory));
        registerPacket(typeof(NMSG_UpdateItemInventory));
        registerPacket(typeof(NMSG_RefreshShop));
        registerPacket(typeof(NMSG_BuyRequest));
    }
    public bool registerPacket(System.Type packet)
    {
        if(!packet.GetType().IsInstanceOfType(typeof(NMSG)))
        {
            throw new System.Exception("Type of packet must be NMSG");
        }
        if(packets.Count >= 256)
        {
            throw new System.Exception("Packets count exceed limit of 255");
        }
        if(packets.Contains(packet))
        {
            throw new System.Exception("Packet already registered");
        }
        packets.Add(packet);
        return true;
    }
}
Server class
c#
private void Start()
    {
        INSTANCE = this;
        NetworkSide.side = NetworkSide.Side.SERVER;
        mysql = new Mysql();
        if (!mysql.openMysqlConnection())
        {
            Debug.Log("ERROR- Server data center not active server closed...");
            return;
        }
        serverProperties = new ServerProperties();
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();
        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliableChannel = cc.AddChannel(QosType.Unreliable);
        HostTopology topo = new HostTopology(cc, serverProperties.MAX_CONNECTION);
        hostId = NetworkTransport.AddHost(topo, serverProperties.port, null);
        packetHandler = new PacketHandler();
        registerCommand(new CommandHelp("help", "display all commands", null));
        registerCommand(new CommandGive("give", "give item to specified player", new string[] { "<Username>", "<ItemId>" }));
        registerCommand(new CommandStop("stop", "stop server", null));
        EventManager.registerEvent(new DeathEvent());
        EventManager.registerEvent(new AreaQuitEvent());
        EventManager.registerEvent(new AreaEnterEvent());
        EventManager.registerEvent(new DamageEvent());
        ItemInitializer.loadItems();
        world = new World();
        world.Load();
        Debug.Log("Server started in port : " + serverProperties.port);
        Debug.Log("Max Slot = " + serverProperties.MAX_CONNECTION);
        Debug.Log("You can configurate server data in serverProperties.properties");
        isStarted = true;
    }
as you can see all NMSG class was greatly registered in start function
client :
c#
    void Start()
    {
        client = this;
        packetHandler = new PacketHandler();
        NetworkSide.side = NetworkSide.Side.CLIENT;
        EventManager.registerEvent(new AreaQuitEvent());
        EventManager.registerEvent(new AreaEnterEvent());
        ConnectToServer("127.0.0.1",port);
    }
same for client
now I will debug list "packets" to see what it contains
Server console :
c#
packets count (Server) 15
NMSG_CreatePlayer
NMSG_UpdatePlayer
NMSG_UpdatePlayerState
NMSG_CreateAccount
NMSG_RegisterMessage
NMSG_ConnectAccount
NMSG_ConnectionMessage
NMSG_ActivateAccountProcess
NMSG_DisconnectAccount
NMSG_PlayerDataTransmission
NMSG_UpdateAccountData
NMSG_UpdateInventory
NMSG_UpdateItemInventory
NMSG_RefreshShop
NMSG_BuyRequest
UnityEngine.Debug:Log(Object)
Server:Start() (at Assets/Scripts/Network/Server.cs:90)
Client console :
c#
packets count (Client) 15
NMSG_CreatePlayer
NMSG_UpdatePlayer
NMSG_UpdatePlayerState
NMSG_CreateAccount
NMSG_RegisterMessage
NMSG_ConnectAccount
NMSG_ConnectionMessage
NMSG_ActivateAccountProcess
NMSG_DisconnectAccount
NMSG_PlayerDataTransmission
NMSG_UpdateAccountData
NMSG_UpdateInventory
NMSG_UpdateItemInventory
NMSG_RefreshShop
NMSG_BuyRequest
UnityEngine.Debug:Log(Object)
Client:Start() (at Assets/Scripts/Network/Client.cs:64)
so it's impossible that packets list contains is empty I don't understand why it doesn't work ...
