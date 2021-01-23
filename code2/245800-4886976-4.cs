    public class StickerRollerVisitor : IStickerVisitor
    {
        private RollList rollList;
        public StickerRollerVisitor(RollList list)
        {
            this.rollList = list;
        }
        public void Visit(NewRollSticker sticker)
        {
            // Next 9999 sticker should be in the form of NN0001 to NN9999
        }
        public void Visit(EnumeratedSticker sticker)
        {
            // Add 9999 stickers to the list, other business logic...
        }
        public void Visit(QualitySticker sticker)
        {
            // Stop the machine and notify the worker
        }
    }
