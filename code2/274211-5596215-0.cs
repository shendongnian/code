    public class PciCardSlot
        {
            private int slotId;
            private int clockFreq;
            public PciDevice cardInSlot;
            public void setCard(PciDevice card)
            {
                cardInSlot = card;
            }
        }
