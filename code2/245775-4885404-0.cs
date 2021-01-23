    if (sticker is StickerNewRoll)
    {
        // Next 9999 sticker should be in the form of NN0001 to NN9999
    }
    else if (sticker is EnumeratedSticker)
    {
        // Add 9999 stickers to the list, other business logic...
    }
    else if (sticker is QualitySticker)
    {
        // Stop the machine and notify the worker
    }
...
