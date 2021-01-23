    public void CreateSquads(int playerNum)
    {
        
        select (playerNum)
        {
            case 1:
                for (int i = 0; i < 15; i++)
                {
                    ply1Squads[i] = new Squad();
                }
                break;
            case 2:
                for (int i = 0; i < 15; i++)
                {
                    ply2Squads[i] = new Squad();
                }
                break;
            default:
                // Handle wrong number here
                break;
        }
    }
